using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WpfStopWatch
{
    public class ObservableStack<T> : Stack<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public ObservableStack()
        {
        }

        public ObservableStack(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                base.Push(item);
            }
        }

        public ObservableStack(List<T> list)
        {
            foreach (var item in list)
            {
                base.Push(item);
            }
        }

        public new virtual void Clear()
        {
            base.Clear();
            NotifyCollectionChanded(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public new virtual T Pop()
        {
            var item = base.Pop();
            NotifyCollectionChanded(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            return item;
        }

        public new virtual void Push(T item)
        {
            base.Push(item);
            NotifyCollectionChanded(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected virtual void NotifyCollectionChanded(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
