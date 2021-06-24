using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Launcher
{
    class MainView
    {
        private int _numberOfImages;
        private List<ImageBrush> _images;
        private int _currentIndex;
        private int _timeoutBetweenImages;
        private Task _carrouselTask;

        public MainView(int timeoutBetweenImages = 1500)
        {
            _numberOfImages = 0;
            _images = new List<ImageBrush>();
            _currentIndex = 0;
            _timeoutBetweenImages = timeoutBetweenImages;
            _carrouselTask = new Task(PlayCarrousel);
        }

        public MainView(List<ImageBrush> images, int timeoutBetweenImages = 1500)
        {
            _numberOfImages = images.Count;
            _images = images;
            _currentIndex = 0;
            _timeoutBetweenImages = timeoutBetweenImages;
            _carrouselTask = new Task(PlayCarrousel);
        }

        public MainView(List<ImageBrush> images, int currentIndex, int timeoutBetweenImages = 1500)
        {
            _numberOfImages = images.Count;
            _images = images;
            CheckIndex(currentIndex);
            _currentIndex = currentIndex;
            _timeoutBetweenImages = timeoutBetweenImages;
            _carrouselTask = new Task(PlayCarrousel);
        }

        public int CurrentIndex
        {
            get => _currentIndex;
            set => _currentIndex = value;
        }

        public int TimeoutBetweenImages
        {
            get => _timeoutBetweenImages;
            set => _timeoutBetweenImages = value;
        }

        public int NumberOfImages => _numberOfImages;

        public bool IsRotating => IsCarrouselRotating();

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _numberOfImages)
                throw new ArgumentException(
                    $"Error: expected starting index between 0 included and the number of images ({_numberOfImages})excluded but got {index}");
        }

        private bool IsCarrouselRotating()
        {
            return _timeoutBetweenImages >= 0;
        }

        public List<ImageBrush> GetImageBrushesCopy()
        {
            List<ImageBrush> copy = new List<ImageBrush>();
            foreach (ImageBrush imageBrush in _images)
                copy.Add(imageBrush);
            return copy;
        }

        public ImageBrush GetCurrentBrush()
        {
            return _images[_currentIndex];
        }

        private void Increment()
        {
            _currentIndex = (_currentIndex + 1) % _numberOfImages;
        }

        private void PlayCarrousel()
        {
            if (IsCarrouselRotating())
            {
                Increment();
                Thread.Sleep(_timeoutBetweenImages);
                PlayCarrousel();
            }
        }

        public void StartCarrousel()
        {
            _carrouselTask.Start();
            _carrouselTask.Wait();
        }

        public void StopCarrousel()
        {
            _timeoutBetweenImages = -1;
        }

        public void AddImageBrush(ImageBrush image, int index = -1)
        {
            if (index == -1)
                _images.Add(image);
            else
                _images.Insert(index, image);
            _numberOfImages += 1;
        }

        public void RemoveImageBrush(ImageBrush image)
        {
            _images.Remove(image);
            _numberOfImages -= 1;
        }

        public void RemoveImageBrush(int index)
        {
            _images.RemoveAt(index);
            _numberOfImages -= 1;
        }

        public void ChangeImageBrushAt(ImageBrush newImage, int index)
        {
            CheckIndex(index);
            _images[index] = newImage;
        }

        public int FindImageIndex(ImageBrush imageBrush)
        {
            return _images.FindIndex((ImageBrush imageBrushL) => imageBrush == imageBrushL);
        }

        public ImageBrush FindImage(ImageBrush imageBrush)
        {
            return _images.Find((ImageBrush imageBrushL) => imageBrush == imageBrushL);
        }

        public bool IsIndexValid(int index)
        {
            return index >= 0 && index < _numberOfImages;
        }

        public ImageBrush GetImageBrushAt(int index)
        {
            CheckIndex(index);
            return _images[index];
        }

        public void ReplaceImage(ImageBrush imageBrush)
        {
            int imageIndex = FindImageIndex(imageBrush);
            RemoveImageBrush(imageIndex);
            AddImageBrush(imageBrush, imageIndex);
        }

        public void Decrement()
        {
            if (_currentIndex == 0)
                _currentIndex = _numberOfImages - 1;
            else
                _currentIndex -= 1;
        }
    }
}
