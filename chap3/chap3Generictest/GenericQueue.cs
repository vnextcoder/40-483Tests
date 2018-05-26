using System;

namespace Generictest {

    class GenericQueue<T> {

        public void Enqueue (T data) {

        }

        // public T DeQueue () {
        //     return null;
        // }
        public void Swap<T> (ref T valueOne, ref T valueTwo) {
            T temp = valueOne;
            valueOne = valueTwo;
            valueTwo = temp;
        }
    }
}