import { CartItem } from "./CartItem.model";


export class CartItemPrice {
    public cartItems: CartItem[];
    public total: number;

    constructor(cartItems: CartItem[], total: number) {
        this.cartItems = cartItems;
        this.total = total;
    }
}