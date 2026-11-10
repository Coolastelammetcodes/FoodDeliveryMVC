using domain.dto;
using domain.entities;
using domain.interfaces;

public class BasePriceCalculator : IOrderPriceCalculator
{
    private readonly IDishRepository _dishRepo;
    public BasePriceCalculator(IDishRepository dishRepo) => _dishRepo = dishRepo;

    public async Task<OrderCalculationResultDTO> CalculateAsync(OrderRequestDTO req)
    {
        var items = req.OrderItems.Select(oi => new OrderItem {DishID = oi.DishID, Quantity = oi.Quantity}).ToList();
        decimal itemsTotal = 0;

        foreach(var item in items)
        {
            item.Dish = await _dishRepo.ViewSpecificDishAsync(item.DishID);
            
            if(item.Dish != null) itemsTotal += item.Dish.Price * item.Quantity;
        }
        return new OrderCalculationResultDTO { OrderItems = items, ItemsTotal = itemsTotal, TotalPrice = itemsTotal };
    }   
}