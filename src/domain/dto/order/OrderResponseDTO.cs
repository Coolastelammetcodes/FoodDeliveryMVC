namespace domain.dto;
public record class OrderResponseDTO(Guid Id, List<OrderItemResponseDTO> OrderItems);