namespace SunriseClothingStore.Models;

public class Cart
{
    private readonly List<OrderLine> _selections = new();
    public IEnumerable<OrderLine> Selections => _selections;

    public Cart AddItem(Product product, int quantity)
    {
        var line = _selections.FirstOrDefault(line => line.ProductId == product.Id);
        if (line != null)
        {
            line.Quantity += quantity;
        }
        else
        {
            _selections.Add(new OrderLine
            {
                ProductId = product.Id,
                Product = product,
                Quantity = quantity
            });
        }

        return this;
    }

    public Cart RemoveItem(Guid productId)
    {
        _selections.RemoveAll(line => line.ProductId == productId);
        return this;
    }

    public void Clear() => _selections.Clear();
   
}