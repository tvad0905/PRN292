using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4_Project.DTL
{
    public class OrderDetail
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        private int orderid;
        public int Orderid
        {
            get { return orderid; }
            set { this.orderid = value; }
        }

        private int albumid;
        public int Albumid
        {
            get { return albumid; }
            set { this.albumid = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { this.quantity = value; }
        }

        private float uniPrice;
        public float UniPrice
        {
            get { return uniPrice; }
            set { this.uniPrice = value; }
        }

        public OrderDetail(int id, int orderid, int albumid, int quantity, float uniPrice)
        {
            this.id = id;
            this.orderid = orderid;
            this.albumid = albumid;
            this.quantity = quantity;
            this.uniPrice = uniPrice;
        }
        public OrderDetail( int orderid, int albumid, int quantity, float uniPrice)
        {
            this.orderid = orderid;
            this.albumid = albumid;
            this.quantity = quantity;
            this.uniPrice = uniPrice;
        }
    }
}
