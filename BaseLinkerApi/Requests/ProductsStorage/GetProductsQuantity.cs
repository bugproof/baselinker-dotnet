using System;
using BaseLinkerApi.Requests.ExternalStorages;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows to retrieve stock from the BaseLinker storage or the shop/wholesaler storage connected to BaseLinker.
/// </summary>
[Obsolete]
public class GetProductsQuantity : GetExternalStorageProductsQuantity
{
}