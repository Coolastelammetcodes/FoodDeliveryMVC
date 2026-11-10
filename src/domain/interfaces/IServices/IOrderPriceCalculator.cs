using domain.dto;

public interface IOrderPriceCalculator
{
    Task<OrderCalculationResultDTO> CalculateAsync(OrderRequestDTO req);  
}