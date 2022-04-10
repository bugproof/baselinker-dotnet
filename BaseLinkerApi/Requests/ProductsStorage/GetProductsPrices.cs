using System;
using BaseLinkerApi.Requests.ExternalStorages;

namespace BaseLinkerApi.Requests.ProductsStorage;

/// <summary>
/// The method allows you to fetch prices of products from the BaseLinker storage or the shop/wholesaler storage connected to BaseLinker.
/// </summary>
[Obsolete]
public class GetProductsPrices : GetExternalStorageProductsPrices
{
}