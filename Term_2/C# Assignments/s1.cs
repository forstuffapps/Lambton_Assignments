using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Product
{
    private String productID;
    private String name;
    private String description;
    private double unitPrice;

    public Product(String productID, String name)
    {
        this.productID = productID;
        this.name = name;
        this.description = "";
        this.unitPrice = 0.0;
    }

    public Product(String productID, String name, double unitPrice)
    {
        this.productID = productID;
        this.name = name;
        this.description = "";
        if (unitPrice < 0.0)
        {
            this.unitPrice = 0.0;
        }
        else
        {
            this.unitPrice = unitPrice;
        }
    }

    public Product(String productID, String name, double unitPrice, String description)
    {
        this.productID = productID;
        this.name = name;
        if (unitPrice < 0.0)
        {
            this.unitPrice = 0.0;
        }
        else
        {
            this.unitPrice = unitPrice;
        }
        this.description = description;
    }

    public Product(Product prdToCopy)
    {
        this.productID = prdToCopy.productID;
        this.name = prdToCopy.name;
        this.description = prdToCopy.description;
        this.unitPrice = prdToCopy.unitPrice;
    }

    public String getProductID()
    {
        return productID;
    }

    public void setProductID(String productID)
    {
        this.productID = productID;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    public double getUnitPrice()
    {
        return unitPrice;
    }

    public void setUnitPrice(double unitPrice)
    {
        if (unitPrice >= 0.0)
        {
            this.unitPrice = unitPrice;
        }
    }

  
    public String ToString()
    {
        return name + " : $" + String.Format("%.2f", unitPrice);
    }
    override
    public Boolean Equals(Object obj)
    {
       
       if (obj.GetType() == typeof(Product)) {
           Product other = (Product)obj;
            return this.productID.Equals(other.productID);
       }
        return false;
    }
}
public class CartItem
{
    private Product prod;
    private int quantity;

    public CartItem(Product prod, int quantity)
    {
        this.prod = prod;
        if (quantity <= 0)
        {
            this.quantity = 1;
        }
        else
        {
            this.quantity = quantity;
        }
    }

    public CartItem(CartItem crtItmToCopy)
    {
        this.prod = new Product(crtItmToCopy.prod);
        this.quantity = crtItmToCopy.quantity;
    }

    public int addQuantity(int quantity)
    {
        this.quantity += quantity;
        return this.quantity;
    }

    public int subQuantity(int quantity)
    {
        this.quantity -= quantity;
        if (this.quantity < 0)
        {
            this.quantity = 0;
        }
        return this.quantity;
    }

    public void setProd(Product prod)
    {
        this.prod = prod;
    }

    public Product getProd()
    {
        return this.prod;
    }

    public void setQuantity(int quantity)
    {
        if (quantity > 0)
        {
            this.quantity = quantity;
        }
    }

    public int getQuantity()
    {
        return this.quantity;
    }

    public double getTotal()
    {
        return prod.getUnitPrice() * quantity;
    }

    public override string ToString()
    {
        return $"{prod.getName()} ( {quantity} @ ${prod.getUnitPrice()} )";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        CartItem other = (CartItem)obj;
        return (quantity == other.quantity && prod.getProductID() == other.prod.getProductID());
    }
}
public class ShoppingCart
{
    private List<CartItem> cart;

    // Constructor to initialize cart to empty list
    public ShoppingCart()
    {
        cart = new List<CartItem>();
    }

    // Copy constructor to create a deep copy of the provided ShoppingCart
    public ShoppingCart(ShoppingCart cartToCopy)
    {
        cart = new List<CartItem>();
        foreach (CartItem item in cartToCopy.cart)
        {
            cart.Add(new CartItem(item));
        }
    }

    // Get the total number of items in the ShoppingCart
    public int GetAllItemsCount()
    {
        int count = 0;
        foreach (CartItem item in cart)
        {
            count += item.getQuantity();
        }
        return count;
    }

    // Get the total number of distinct items in the ShoppingCart
    public int GetDistinctItemsCount()
    {
        return cart.Count;
    }

    // Get the CartItem with the specified id
    public CartItem GetCartItem(string id)
    {
        foreach (CartItem item in cart)
        {
            if (item.getProd().getProductID() == id)
            {
                return new CartItem(item);
            }
        }
        return null;
    }

    // Get the CartItem at the specified index
    public CartItem GetCartItem(int index)
    {
        if (index < 0 || index >= cart.Count)
        {
            return null;
        }
        return new CartItem(cart[index]);
    }

    // Add a new CartItem to the end of the ShoppingCart
    public void AddItem(CartItem crtItm)
    {
      
        cart.Add(crtItm);
    }

    // Get the total value of CartItems in the ShoppingCart
    public double GetTotal()
    {
        double total = 0;
        foreach (CartItem item in cart)
        {
            total += item.getTotal();
        }
        return total;
    }

    // Override the ToString() method to return a string representation of the ShoppingCart
    public override string ToString()
    {
        string result = "";
        foreach (CartItem item in cart)
        {
            result += item.ToString() + "\n";
        }
        return result;
    }

    // Override the Equals() method to compare two ShoppingCarts and their CartItems
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        ShoppingCart other = (ShoppingCart)obj;
        if (cart.Count != other.cart.Count)
        {
            return false;
        }
        for (int i = 0; i < cart.Count; i++)
        {
            if (!cart[i].Equals(other.cart[i]))
            {
                return false;
            }
        }
        return true;
    }

    // Remove the CartItem at the specified index
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < cart.Count)
        {
            cart.RemoveAt(index);
        }
    }

    // Remove all items from the ShoppingCart
    public void Clear()
    {
        cart.Clear();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create 5 Products
        Product product1 = new Product("1", "Apple", 0.99, "A fresh apple");
        Product product2 = new Product("2", "Banana", 1.49, "A ripe banana");
        Product product3 = new Product("3", "Milk", 3.99, "1 gallon of whole milk");
        Product product4 = new Product("4", "Eggs", 2.49, "A dozen large eggs");
        Product product5 = new Product("5", "Bread", 2.99, "A loaf of whole wheat bread");

        // Step 2: Create 5 CartItems
        CartItem cartItem1 = new CartItem(product1, 3);
        CartItem cartItem2 = new CartItem(product2, 2);
        CartItem cartItem3 = new CartItem(product3, 1);
        CartItem cartItem4 = new CartItem(product4, 4);
        CartItem cartItem5 = new CartItem(product5, 1);

        // Step 3: Create an instance of ShoppingCart and add CartItems
        ShoppingCart shoppingCart = new ShoppingCart();
        shoppingCart.AddItem(cartItem1);
        shoppingCart.AddItem(cartItem3);
        shoppingCart.AddItem(cartItem2);
        shoppingCart.AddItem(cartItem4);
        shoppingCart.AddItem(cartItem5);

        // Step 4: Demonstrate the functionality of getCartItem method
        CartItem retrievedCartItem1 = shoppingCart.GetCartItem(0);
        Console.WriteLine("Retrieved cart item by index: " + retrievedCartItem1.ToString());

        CartItem retrievedCartItem2 = shoppingCart.GetCartItem("3");
        Console.WriteLine("Retrieved cart item by ID: " + retrievedCartItem2.ToString());

        // Step 5: Print the contents of the ShoppingCart
        Console.WriteLine("Shopping cart contents: ");
        Console.WriteLine(shoppingCart.ToString());

        // Step 6: Print the total cost of the ShoppingCart
        double totalCost = shoppingCart.GetTotal();
        Console.WriteLine("Shopping cart total cost: " + totalCost.ToString("C", CultureInfo.CurrentCulture));
    }
}