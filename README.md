# Fawry E-Commerce Checkout System 🛒

A clean and modular C# console application implementing the Fawry Quantum Internship Challenge 3 – a simplified e-commerce system with cart functionality, product expiration, shipping calculation, and checkout logic.

## ✅ Features

- 🧾 **Products**
  - Name, Price, Quantity
  - Expirable or Non-Expirable
  - Shippable or Non-Shippable

- 🛒 **Cart**
  - Add products with quantity (validates against available stock)
  - Prevent duplicate product entries (merge quantities)

- 🚚 **Shipping**
  - Products implementing `IShippable` provide `GetName()` and `GetWeight()`
  - Shipping fee = 10 EGP per kg
  - Shipping items grouped and total weight printed

- 💳 **Checkout**
  - Subtotal, shipping, total amount, and balance left printed
  - Fails with meaningful errors if:
    - Cart is empty
    - Product is out of stock
    - Product is expired
    - Customer has insufficient balance

## 💡 Architecture

- Clean layered design:
  - `ProductModule` → defines domain logic (products, expiration)
  - `CartModule` → manages `CartItem` and `CustomerCart`
  - `CustomerModule` → handles customer and balance
  - `Services` → `CheckoutService`, `ShippingService`, `ReceiptPrinterService`
  - `ServiceAbstractions` → interfaces for abstraction and DI

## 🧠 Design Patterns Used

- **Adapter Pattern**  
  - Used to wrap `Product` objects that need to be `IShippable`

- **Interface-Based Design (SOLID)**  
  - All core services depend on abstractions (`IShippingService`, `IReceiptPrinterService`, `ICheckOutService`)

- **Single Responsibility Principle**  
  - Each class handles a single concern (e.g., printing receipt, calculating shipping)

## 🧪 Example Code Flow

```csharp
// Customer setup
var customer = new Customer { Id = 1, Name = "Mohamed", Balance = 1000 };

var cheese = new ExpirableProduct { Id = 1, Name = "Cheese", Price = 100, Quantity = 5, ExpiryDate = DateTime.Now.AddDays(2) };
var biscuits = new ExpirableProduct { Id = 2, Name = "Biscuits", Price = 150, Quantity = 5, ExpiryDate = DateTime.Now.AddDays(5) };
var scratchCard = new NonExpirableProduct { Id = 3, Name = "ScratchCard", Price = 50, Quantity = 10 };

// Wrap shippables
var shippableCheese = new ShippableProductAdapter(cheese, 0.3);
var shippableBiscuits = new ShippableProductAdapter(biscuits, 0.7);

customer.Cart.AddItem(shippableCheese, 2);        // 200 EGP
customer.Cart.AddItem(shippableBiscuits, 1);      // 150 EGP
customer.Cart.AddItem(scratchCard, 1);   // 50 EGP

// Checkout
checkoutService.Checkout(customer, customer.Cart);

```

### ✅ Console Output

```
** Shipment notice **
2x Cheese        400g
1x Biscuits      700g
Total package weight 1.1kg

** Checkout receipt **
2x Cheese        200
1x Biscuits      150
1x ScratchCard   50
----------------------
Subtotal         400
Shipping         11
Amount           411
Balance left     589
```

## 🚀 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/Mohamed-Magdy-Dewidar/fawry-ecommerce-task
   ```

2. Open in Visual Studio or run:
   ```bash
   dotnet run
   ```

## 📁 Project Structure

```
Ecommerce-Fawry-Task/
│
├── Program.cs
├── ProductModule/
├── CartModule/
├── CustomerModule/
├── Shipping/
├── Services/
└── ServiceAbstractions/
```

## 📌 Assumptions

- Shipping rate is fixed at **10 EGP/kg**
- Product weight is per-unit
- Expired products are excluded from checkout
- Non-shippable items do not go to `ShippingService`

## 👨‍💻 Author

Mohamed Magdy – Nile University  
Submitted as part of the **Fawry Rise Full Stack Internship**

---

> “Build clean. Fail fast. Ship smart.” 💼
