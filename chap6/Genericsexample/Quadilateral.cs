using System;
namespace Genericsexample {
    //http://www.functionx.com/csharp2/collections/Lesson04e.htm
    public interface IGeometry<T> {
        string Name { get; set; }
        void Display ();
    }

    public class Round<T> : IGeometry<T> {
        private string _name;

        public Round () {
            _name = "Unknown";
        }
        public Round (string name) {
            _name = name;
        }

        public virtual string Name {
            get { return _name; }
            set { _name = value; }
        }

        public virtual void Display () {
            Console.WriteLine ("Name: {0}", Name);
        }
    }
    public class Quadrilateral<T> {
        protected T _base;
        protected T _height;
        protected string _name;

        public virtual T Base {
            get { return _base; }
            set { _base = value; }
        }

        public virtual T Height {
            get { return _height; }
            set { _height = value; }
        }

        public virtual string Name {
            get { return _name; }
            set { _name = value; }
        }

        public Quadrilateral () {
            _name = "Quadrilateral";
        }

        public Quadrilateral (string name) {
            _name = "Quadrilateral";
        }

        public Quadrilateral (T bs, T height) {
            _name = "Quadrilateral";
            _base = bs;
            _height = height;
        }

        public Quadrilateral (string name, T bs, T height) {
            _name = name;
            _base = bs;
            _height = height;
        }

        public virtual string Describe () {
            return "A quadrilateral is a geometric figure with four sides";
        }

        public virtual void ShowCharacteristics () {
            Console.WriteLine ("Geometric Figure: {0}", Name);
            Console.WriteLine ("Description:      {0}", Describe ());
            Console.WriteLine ("Base:             {0}", Base);
            Console.WriteLine ("Height:           {0}", Height);
        }
    }
    public class Square<T> : Quadrilateral<T> {
        public Square () {
            _name = "Square";
        }
        public Square (string name) {
            _name = "Square";
        }
        public Square (T side) {
            _name = "Square";
            _base = side;
            _height = side;
        }
        public Square (string name, T side) {
            _name = name;
            _base = side;
            _height = side;
        }
        public override string Describe () {
            return "A square is a quadrilateral with four equal sides";
        }
        public override void ShowCharacteristics () {
            Console.WriteLine ("Geometric Figure: {0}", Name);
            Console.WriteLine ("Description:      {0}", Describe ());
            Console.WriteLine ("                  {0}", Describe ());
            Console.WriteLine ("Side:             {0}", Base);
        }
    }
}