using System;
namespace chap3Encapsulated {
    public class Matrix {
        private int[,] matrix =new int[4,4];
        public int this [int index,int index2] {
            get {
                return matrix[index,index2];
            }
            set {
                if (value >= 0 || value <=10)
                    matrix[index,index2] = value;
                else
                    throw new Exception ("Invalid value");
            }
        }
        
    }

}