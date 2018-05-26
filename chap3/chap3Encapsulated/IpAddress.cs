using System;
namespace chap3Encapsulated {
    public class IPAddress {
        private int[] ip =new int[32];
        public int this [int index] {
            get {
                return ip[index];
            }
            set {
                if (value == 0 || value == 1)
                    ip[index] = value;
                else
                    throw new Exception ("Invalid value");
            }
        }
        
    }

}