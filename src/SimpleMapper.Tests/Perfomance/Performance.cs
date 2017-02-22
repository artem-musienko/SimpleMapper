using System;
using System.Diagnostics;
using System.Globalization;
using NUnit.Framework;
using NUnit.Framework;

namespace SimpleMapper.Tests
{

    public class Performance
    {
        private class Order
        {
            public int OrderId { get; set; }
            public DateTime DateTime { get; set; }
            public string Description { get; set; }
        }

        private class OrderDto
        {
            public string OrderId { get; set; }
            public string DateTime { get; set; }
            public string Description { get; set; }
        }

        private const int Length = 2000000;
        private readonly Order[] _orders;

        public Performance()
        {
            Debug.Listeners.Add(new DefaultTraceListener());
            _orders = new Order[Length];
            for (int i = 0; i < Length; i++)
            {
                _orders[i] = new Order { DateTime = DateTime.Now, Description = "Order " + i + 1, OrderId = i + 1 };
            }
        }

       [Test]
        public void Hand_coded()
        {
            var watch = new Stopwatch();
            watch.Start();
            var orderDtos1 = new OrderDto[Length];
            for (int i = 0; i < Length; i++)
            {
                var order = _orders[i];
                orderDtos1[i] =
                    new OrderDto
                    {
                        DateTime = order.DateTime.ToString(CultureInfo.InvariantCulture),
                        Description = order.Description,
                        OrderId = order.OrderId.ToString(CultureInfo.InvariantCulture)
                    };
            }
            watch.Stop();
            Debug.WriteLine("Hard-coded: {0:0.0000} sec", watch.ElapsedMilliseconds / 1000.0);
            Debug.Write(orderDtos1[0]);
        }

        [Test]
        public void Simplemapper()
        {
            var watch = new Stopwatch();
            Mapper.Create<Order[], OrderDto[]>();
            watch.Start();
            var orderDtos2 = _orders.Map<Order[], OrderDto[]>();
            Debug.Write(orderDtos2[0]);
            watch.Stop();
            Debug.WriteLine("Map: {0:0.0000} sec", watch.ElapsedMilliseconds / 1000.0);
        }

        [Test]
        public void Automapper()
        {
            var watch = new Stopwatch();
            AutoMapper.Mapper.CreateMap<Order, OrderDto>();
            watch.Start();
            var orderDtos3 = AutoMapper.Mapper.Map<Order[], OrderDto[]>(_orders);
            Debug.Write(orderDtos3[0]);
            watch.Stop();
            Debug.WriteLine("Map using AutoMapper: {0:0.0000} sec", watch.ElapsedMilliseconds / 1000.0);

        }
    }
}
