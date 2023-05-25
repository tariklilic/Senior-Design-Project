export class Product {
    public type: string;
    public name: string;
    public manufacturer: string;
    public shortdescription: string;
    public price: number;
    public rating: number;
    public quantity: number;
    public longdescription: string;
    public cover: string;
    public images: string[];

    constructor(type: string, name: string, manufacturer: string, shortdescription: string, price: number, rating: number, quantity: number, longdescription: string, cover: string, images: string[]) {
        this.type = type
        this.name = name;
        this.manufacturer = manufacturer;
        this.shortdescription = shortdescription;
        this.price = price;
        this.rating = rating;
        this.quantity = quantity;
        this.longdescription = longdescription;
        this.cover = cover;
        this.images = images;
    }
}