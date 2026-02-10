using ProductEnumerable;

static IEnumerable<Product> GetProductsWithDynamicDiscount(
    List<Product> products,
    decimal discountPercent
)
{
    foreach (var p in products)
    {
        yield return new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price * (1 - discountPercent / 100),
            Category = p.Category,
        };
    }
}

static IEnumerable<Product> WithYield(List<Product> products, decimal discount)
{
    Console.WriteLine("  [WithYield] Method invoked!");

    foreach (var p in products)
    {
        Console.WriteLine($"  [WithYield] working on {p.Name}");
        yield return new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price * (1 - discount / 100),
            Category = p.Category,
        };
    }

    Console.WriteLine("  [WithYield] Method finished!");
}

static List<Product> WithoutYield(List<Product> products, decimal discount)
{
    Console.WriteLine("  [WithoutYield] Method invoked!");

    var result = new List<Product>();
    foreach (var p in products)
    {
        Console.WriteLine($"  [WithoutYield] working on {p.Name}");
        result.Add(
            new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price * (1 - discount / 100),
                Category = p.Category,
            }
        );
    }

    Console.WriteLine("  [WithoutYield] Method finished!");
    return result;
}

var products = new List<Product>
{
    new Product
    {
        Id = 1,
        Name = "Laptop",
        Price = 1000,
        Category = "Electronics",
    },
    new Product
    {
        Id = 2,
        Name = "Mouse",
        Price = 20,
        Category = "Electronics",
    },
    new Product
    {
        Id = 3,
        Name = "Book",
        Price = 15,
        Category = "Books",
    },
    new Product
    {
        Id = 4,
        Name = "Pen",
        Price = 2,
        Category = "Office",
    },
    new Product
    {
        Id = 5,
        Name = "Monitor",
        Price = 300,
        Category = "Electronics",
    },
};

var collection = new ProductPagedCollection(products, pageSize: 3, pageNumber: 1);
Console.WriteLine("****** Start Test ProductPagedCollection ******");
Console.WriteLine("=== Test GetEnumerator ===");
foreach (var product in collection)
{
    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}");
}
foreach (var product in collection)
{
    Console.WriteLine($"ID: {product.Id}, Name: {product.Name}");
}
Console.WriteLine("****** Finish Test ProductPagedCollection ******");

Console.WriteLine("****** Test ProductFilteredEnumerator *****");
var enumerator = new ProductFilteredEnumerator(products, "Electronics");

Console.WriteLine("=== First MoveNext ===");
bool hasNext = enumerator.MoveNext();
Console.WriteLine($"MoveNext return: {hasNext}");
if (hasNext)
    Console.WriteLine($"Current: {enumerator.Current.Name}");

Console.WriteLine("\n=== Second MoveNext ===");
hasNext = enumerator.MoveNext();
Console.WriteLine($"MoveNext return: {hasNext}");
if (hasNext)
    Console.WriteLine($"Current: {enumerator.Current.Name}");

Console.WriteLine("\n=== Third MoveNext ===");
hasNext = enumerator.MoveNext();
Console.WriteLine($"MoveNext return: {hasNext}");
if (hasNext)
    Console.WriteLine($"Current: {enumerator.Current.Name}");

Console.WriteLine("****** Finish Test ProductFilteredEnumerator *****");

Console.WriteLine("****** Test GetProductsWithDynamicDiscount *****");

Console.WriteLine("=== Test 1: with yield ===");
Console.WriteLine("Calling method...");
var withYield = WithYield(products, 10);
foreach (var p in withYield.Take(2))
{
    Console.WriteLine($">>> Recieved: {p.Name}");
}

Console.WriteLine("\n=== Test 2: without yield ===");
Console.WriteLine("Calling method...");
var withoutYield = WithoutYield(products, 10);
foreach (var p in withoutYield.Take(2))
{
    Console.WriteLine($">>> Received: {p.Name}");
}
