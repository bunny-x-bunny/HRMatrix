using HRMatrix.Application.DTOs.Order;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMatrix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly UserManager<ApplicationUser> _userManager;

    public OrdersController(IOrderService orderService, UserManager<ApplicationUser> userManager)
    {
        _orderService = orderService;
        _userManager = userManager;
    }


    [HttpGet("my-orders")]
    public async Task<IActionResult> GetMyOrders()
    {
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var orders = await _orderService.GetOrdersByUserIdAsync(user.Id);
        return Ok(orders);
    }

    [HttpPost("{orderId}/respond")]
    public async Task<IActionResult> RespondToOrder(int orderId)
    {
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var responseId = await _orderService.RespondToOrderAsync(orderId, user.Id);
        if (responseId == 0)
            return NotFound("Order not found or already responded");

        return Ok(responseId);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        if (orderDto == null)
        {
            return BadRequest("Order data is required.");
        }

        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var createdOrderId = await _orderService.CreateOrderAsync(orderDto, user.Id);
        return CreatedAtAction(nameof(GetOrderById), new { id = createdOrderId }, createdOrderId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto orderDto)
    {
        if (orderDto == null)
        {
            return BadRequest("Invalid order data.");
        }

        var updatedOrderId = await _orderService.UpdateOrderAsync(orderDto);
        if (updatedOrderId == 0)
        {
            return NotFound();
        }

        return Ok(updatedOrderId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetOrders([FromQuery] string titleQuery,
        [FromQuery] List<int> categoryIds,
        [FromQuery] List<int> specializationIds,
        [FromQuery] List<int> workTypeIds,
        [FromQuery] List<int> cityIds)
    {
        var orders = await _orderService.GetFilteredOrdersAsync(titleQuery, categoryIds, specializationIds, workTypeIds, cityIds);
        return Ok(orders);
    }

    [HttpPost("{orderId}/review")]
    public async Task<IActionResult> AddReviewToOrder(int orderId, [FromBody] AddReviewDto reviewDto)
    {
        if (reviewDto == null || reviewDto.Rating < 1 || reviewDto.Rating > 5)
        {
            return BadRequest("Invalid review data.");
        }

        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var reviewId = await _orderService.AddReviewToOrderAsync(orderId, user.Id, reviewDto.Rating, reviewDto.ReviewText);
        if (reviewId == 0)
            return NotFound("Order not found");

        return CreatedAtAction(nameof(GetOrderReviews), new { orderId }, reviewId);
    }

    [HttpGet("{orderId}/reviews")]
    public async Task<IActionResult> GetOrderReviews(int orderId)
    {
        var reviews = await _orderService.GetReviewsByOrderIdAsync(orderId);
        return Ok(reviews);
    }

    [HttpDelete("reviews/{reviewId}")]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        var result = await _orderService.DeleteReviewAsync(reviewId);
        if (!result)
        {
            return NotFound("Review not found.");
        }

        return NoContent();
    }
}