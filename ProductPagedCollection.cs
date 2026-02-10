using System.Collections;

namespace ProductEnumerable;

public class ProductPagedCollection : IEnumerable<Product>
{
    private readonly List<Product> _allProduct;
    private readonly int _pageSize;
    private readonly int _pageNumber;

    public ProductPagedCollection(List<Product> products, int pageSize, int pageNumber)
    {
        _allProduct = products;
        _pageSize = pageSize;
        _pageNumber = pageNumber;
    }

    public IEnumerator<Product> GetEnumerator() {
      int start = _pageNumber * _pageSize;
      int end = Math.Min(start + _pageSize, _allProduct.Count);
        for(int i = start; i < end; i++){
          yield return _allProduct[i];
        } 
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
