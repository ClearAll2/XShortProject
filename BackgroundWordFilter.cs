using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace XShort
{
    public class BackgroundWordFilter : IDisposable
    {
        private readonly List<string> _items;
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
        private readonly Thread _workerThread;
        private readonly int _maxItemsToMatch;
        private readonly Action<List<string>> _callback;
        private readonly Action<ImageList> _imageList;

        private volatile bool _shouldRun = true;
        private volatile string _currentEntry = null;

        public BackgroundWordFilter(
            List<string> items,
            int maxItemsToMatch,
            Action<List<string>> callback, Action<ImageList> imageList)
        {
            _items = items;
            _callback = callback;
            _maxItemsToMatch = maxItemsToMatch;
            _imageList = imageList;

            // start the long-lived backgroud thread
            _workerThread = new Thread(WorkerLoop)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };

            _workerThread.Start();
        }

        public void SetCurrentEntry(string currentEntry)
        {
            // set the current entry and signal the worker thread
            _currentEntry = currentEntry;
            _signal.Set();
        }

        public void LoadIcon(ImageList imageList, List<String> path)
        {
            imageList.Images.Clear();
            for (int i = 0; i < path.Count; i++)
            {
                try
                {
                    imageList.Images.Add(Icon.ExtractAssociatedIcon(path[i]));
                }
                catch
                {
                    if (path[i].Contains("http"))
                        imageList.Images.Add(Properties.Resources.internet);
                    else if (path[i].Contains("\\"))
                    {
                        if (Directory.Exists(path[i]))
                            imageList.Images.Add(Properties.Resources.dir);
                        else
                            imageList.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        imageList.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }
            }
        }

        void WorkerLoop()
        {
            while (_shouldRun)
            {
                // wait here until there is a new entry
                _signal.WaitOne();
                if (!_shouldRun)
                    return;

                var entry = _currentEntry;
                var results = new List<string>();
                var imageList = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(30, 30)
                };

                // if there is nothing to process,
                // return an empty list
                if (string.IsNullOrEmpty(entry))
                {
                    _callback(results);
                    _imageList(imageList);
                    continue;
                }

                // do the search in a for-loop to 
                // allow early termination when current entry
                // is changed on a different thread
                foreach (var i in _items)
                {
                    // if matched, add to the list of results
                    if (i.ToLower().Contains(entry.ToLower()))
                        results.Add(i);

                    // check if the current entry was updated in the meantime,
                    // or we found enough items
                    if (entry != _currentEntry || results.Count >= _maxItemsToMatch)
                        break;
                }
                LoadIcon(imageList, results);
                if (entry == _currentEntry)
                {
                    _callback(results);
                    _imageList(imageList);
                }
            }
        }

        public void Dispose()
        {
            // we are using AutoResetEvent and a background thread
            // and therefore must dispose it explicitly
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            // shutdown the thread
            if (_workerThread.IsAlive)
            {
                _shouldRun = false;
                _currentEntry = null;
                _signal.Set();
                _workerThread.Join();
            }

            // if targetting .NET 3.5 or older, we have to
            // use the explicit IDisposable implementation
            (_signal as IDisposable).Dispose();
        }
    }
}
