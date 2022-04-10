using System;
using BaseLinkerApi.Requests.ExternalStorages;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows to bulk update the product stock (and/or variants) in BaseLinker storage or in a shop/wholesaler storage connected to BaseLinker. Maximum 1000 products at a time.
/// </summary>
[Obsolete]
public class UpdateProductsQuantity : UpdateExternalStorageProductsQuantity
{
        
}