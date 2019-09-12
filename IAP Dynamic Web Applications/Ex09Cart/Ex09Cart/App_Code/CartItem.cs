public class CartItem
{
    //create empty object or add values on creation
    public CartItem() { }
    public CartItem(Product product, int quantity)
    {
        this.Product = product;
    
        this.Quantity = quantity;

        this.totalCost = (product.UnitPrice * quantity);
    }

    //public properties
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal totalCost;

    //add to quantity
    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
        this.totalCost += quantity * Product.UnitPrice;
    }

    //display item's property values
    public string Display()
    {
        
        string display = string.Format("{0} ({1} at {2} each. Total: £{3})",
            Product.Name, Quantity.ToString(),
            Product.UnitPrice.ToString("c"), this.totalCost.ToString("#.##"));
        return display;
    }
}