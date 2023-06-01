import { CartItem } from "./CartItem.model";

export class PurchaseHistory {
    public historyItems: CartItem[];
    public total: number;

    constructor(historyItems: CartItem[], total: number) {
        this.historyItems = historyItems;
        this.total = total;
    }
}