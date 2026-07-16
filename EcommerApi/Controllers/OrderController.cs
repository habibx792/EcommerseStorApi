using EcommerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectClasses;
using EcommerApi.Data.NewFolder;

namespace EcommerApi.Controllers
{
    [ApiController]
    [Route("Home")]
    public class OrderController : ControllerBase
    {
        private readonly ProjectDbContext context;
        public OrderController(ProjectDbContext context)
        {
            this.context = context;

        }
        private async Task<Order> GetOrder(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(or => or.Id == id);
            return order;
        }
        [HttpGet("Orders")]
        public async Task<ActionResult> GetAllOrders()
        {
            var orders = await context.Orders.ToListAsync();
            return Ok(new { message = "Orders placed ", orders });
        }
        [HttpGet("Orders/{id:int}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var order = await GetOrder(id);
            if (order is null)
            {
                return BadRequest(new { message = "Orders Does Not Exist" });
            }
            return Ok(new { message = $"Orders with {id}", order });

        }
        [HttpPost("PlaceOrder")]
        public async Task<ActionResult> PlaceOrder(PlaceOrderDto dto)
        {
            var user = await context.Users.FindAsync(dto.UserId);

            if (user == null)
                return BadRequest(new { message = "User not found." });

            var products = await context.Products
                .Where(p => dto.ProductIds.Contains(p.Id))
                .ToListAsync();

            if (products.Count != dto.ProductIds.Count)
                return BadRequest(new { message = "One or more products do not exist." });

            var shipper = await context.ShipmentRiders
                .FirstOrDefaultAsync(s => s.Status == shippeManStatus.Free);

            if (shipper == null)
                return NotFound(new { message = "No free shipment rider available." });

            Order order = new Order
            {
                User = user,
                OrderStatus = OrderStatus.Pending
            };

            context.Orders.Add(order);

            foreach (var product in products)
            {
                context.orderProducts.Add(new OrderProduct
                {
                    Order = order,
                    Product = product
                });
            }

            shipper.Status = shippeManStatus.NotFree;

            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Order placed successfully.",
                orderId = order.Id
            });
        }
        [HttpPut("UpdateOrder/{orderId:int}")]
        public async Task<ActionResult> UpdateResult(Order newOrder, int orderId)
        {
            var order = await GetOrder(orderId);
            if (order is null)
            {
                return BadRequest(new { message = "Order Does Not Exist" });
            }
            order.OrderStatus = newOrder.OrderStatus;
            await context.SaveChangesAsync();
            return Ok(order);

        }
        [HttpDelete("DeleteOrder/{id:int}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var oder = await GetOrder(id);
            if (oder is null)
            {
                return BadRequest(new { message = "Order Does Not Exist" });
            }
            await context.Orders.Where(o => o.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
