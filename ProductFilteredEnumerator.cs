using System.Collections;

namespace ProductEnumerable;

public class ProductFilteredEnumerator : IEnumerator<Product>
{
    private readonly List<Product> _products;
    private readonly string _category;
    private int _currentIndex = -1;

    public ProductFilteredEnumerator(List<Product> products, string category)
    {
        _products = products;
        _category = category;
    }

    public Product Current
    {
        get { return _products[_currentIndex]; }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _currentIndex++;
        while (_products.Count > _currentIndex)
        {
            if (_products[_currentIndex].Category == _category)
                return true;
            else
                _currentIndex++;
        }

        return false;
    }

    public void Reset() => _currentIndex = -1;

    public void Dispose() { }
}
