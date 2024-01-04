﻿// .NET 4.x eq, .NET 4.x => Disable
//PLATFORM_IMPLEMENTS_ATTACH_DIALOG;ENABLE_MONO;NET_4_6;ENABLE_PROFILER;UNITY_ASSERTIONS;UNITY_EDITOR;UNITY_EDITOR_64;UNITY_EDITOR_WIN;ENABLE_UNITY_COLLECTIONS_CHECKS;ENABLE_BURST_AOT;UNITY_TEAM_LICENSE;ENABLE_VSTU;
//CSHARP_7_OR_LATER;CSHARP_7_3_OR_NEWER

// .NET 4.x eq, .NET Standard => Disable

// .NET 3.5 eq, .NET 4.x => Enable
//PLATFORM_IMPLEMENTS_ATTACH_DIALOG;ENABLE_MONO;NET_4_6;ENABLE_PROFILER;UNITY_ASSERTIONS;UNITY_EDITOR;UNITY_EDITOR_64;UNITY_EDITOR_WIN;ENABLE_UNITY_COLLECTIONS_CHECKS;ENABLE_BURST_AOT;UNITY_TEAM_LICENSE;ENABLE_VSTU

// .NET 3.5 eq, .NET 2.0 => Enable
//PLATFORM_IMPLEMENTS_ATTACH_DIALOG;ENABLE_MONO;NET_2_0;NET_LEGACY;ENABLE_PROFILER;UNITY_ASSERTIONS;UNITY_EDITOR;UNITY_EDITOR_64;UNITY_EDITOR_WIN;ENABLE_UNITY_COLLECTIONS_CHECKS;ENABLE_BURST_AOT;UNITY_TEAM_LICENSE;ENABLE_VSTU

#if !NET_STANDARD_2_0 && !NETFX_CORE && ((NET_4_6 && !CSHARP_7_OR_LATER && UNITY_2018_3_OR_NEWER) || !NET_4_6)

// ConcurrentQueue.cs
//
// Copyright (c) 2008 Jérémie "Garuma" Laval
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;

namespace System.Collections.Concurrent
{
    public class ConcurrentQueue<T> : /*IProducerConsumerCollection<T>,*/ IEnumerable<T>, ICollection,
                                      IEnumerable, ISerializable, IDeserializationCallback
    {
        class Node
        {
            public T Value;
            public Node Next;
        }

        Node head = new Node();
        Node tail;
        int count;

        public ConcurrentQueue()
        {
            tail = head;
        }

        public ConcurrentQueue(IEnumerable<T> enumerable) : this()
        {
            foreach (T item in enumerable)
            {
                Enqueue(item);
            }
        }

        protected ConcurrentQueue(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            Interlocked.Increment(ref count);

            Node node = new Node();
            node.Value = item;

            Node oldTail = null;
            Node oldNext = null;

            bool update = false;
            while (!update)
            {
                oldTail = tail;
                oldNext = oldTail.Next;

                // Did tail was already updated ?
                if (tail == oldTail)
                {
                    if (oldNext == null)
                    {
                        // The place is for us
                        update = Interlocked.CompareExchange(ref tail.Next, node, null) == null;
                    }
                    else
                    {
                        // another Thread already used the place so give him a hand by putting tail where it should be
                        Interlocked.CompareExchange(ref tail, oldNext, oldTail);
                    }
                }
            }
            // At this point we added correctly our node, now we have to update tail. If it fails then it will be done by another thread
            Interlocked.CompareExchange(ref tail, node, oldTail);
        }

        //bool IProducerConsumerCollection<T>.TryAdd (T item)
        //{
        //	Enqueue (item);
        //	return true;
        //}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool TryDequeue(out T value)
        {
            value = default(T);
            bool advanced = false;
            while (!advanced)
            {
                Node oldHead = head;
                Node oldTail = tail;
                Node oldNext = oldHead.Next;

                if (oldHead == head)
                {
                    // Empty case ?
                    if (oldHead == oldTail)
                    {
                        // This should be false then
                        if (oldNext != null)
                        {
                            // If not then the linked list is mal formed, update tail
                            Interlocked.CompareExchange(ref tail, oldNext, oldTail);
                        }
                        value = default(T);
                        return false;
                    }
                    else
                    {
                        value = oldNext.Value;
                        advanced = Interlocked.CompareExchange(ref head, oldNext, oldHead) == oldHead;
                    }
                }
            }

            Interlocked.Decrement(ref count);
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public bool TryPeek(out T value)
        {
            if (IsEmpty)
            {
                value = default(T);
                return false;
            }

            Node first = head.Next;
            value = first.Value;
            return true;
        }

        internal void Clear()
        {
            count = 0;
            tail = head = new Node();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)InternalGetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return InternalGetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InternalGetEnumerator();
        }

        IEnumerator<T> InternalGetEnumerator()
        {
            Node my_head = head;
            while ((my_head = my_head.Next) != null)
            {
                yield return my_head.Value;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            T[] dest = array as T[];
            if (dest == null)
            {
                return;
            }

            CopyTo(dest, index);
        }

        public void CopyTo(T[] dest, int index)
        {
            IEnumerator<T> e = InternalGetEnumerator();
            int i = index;
            while (e.MoveNext())
            {
                dest[i++] = e.Current;
            }
        }

        public T[] ToArray()
        {
            T[] dest = new T[count];
            CopyTo(dest, 0);
            return dest;
        }

        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }

        bool ICollection.IsSynchronized
        {
            get { return true; }
        }

        protected virtual void OnDeserialization(object sender)
        {
            throw new NotImplementedException();
        }

        void IDeserializationCallback.OnDeserialization(object sender)
        {
            OnDeserialization(sender);
        }

        //bool IProducerConsumerCollection<T>.TryTake (out T item)
        //{
        //  return TryDequeue (out item);
        //}

        object syncRoot = new object();
        object ICollection.SyncRoot
        {
            get { return syncRoot; }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return count == 0;
            }
        }
    }
}
#endif