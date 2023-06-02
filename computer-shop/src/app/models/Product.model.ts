import { ProductImages } from "./ProductImages.model";

export class Product {
    public id: number;
    public name: string;
    public manufacturer: string;
    public shortDesc: string;
    public price: number;
    public rating: number;
    public quantity: number;
    public longDesc: string;
    public cover: string;
    public componentId: number;
    public images: ProductImages;


    constructor(id: number, name: string, manufacturer: string, shortDesc: string, price: number, rating: number, quantity: number, longDesc: string, cover: string, componentId: number, images: ProductImages) {
        this.id = id;
        this.name = name;
        this.manufacturer = manufacturer;
        this.shortDesc = shortDesc;
        this.price = price;
        this.rating = rating;
        this.quantity = quantity;
        this.longDesc = longDesc;
        this.cover = cover;
        this.componentId = componentId;
        this.images = images;
    }
}