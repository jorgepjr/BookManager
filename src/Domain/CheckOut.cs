﻿namespace Domain
{
    public class CheckOut
    {
        protected CheckOut() { }

        public CheckOut(Guid clientId, Guid bookId, int quantity)
        {
            ClientId = clientId;
            BookId = bookId;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid BookId { get; private set; }
        public int Quantity { get; private set; }
        public Inventory Inventory { get; private set; }
    }
}
