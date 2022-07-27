using Features.Purchases.presentation.ui;
using UnityEngine;

namespace Features.Purchases.adapters
{
    public class PurchaseItemSelectionAdapter: DefaultPurchaseItemController.IPurchaseItemSelectionAdapter
    {
        public void SelectItem(long purchaseId)
        {
            Debug.Log($"item selected: {purchaseId.ToString()}");
        }
    }
}