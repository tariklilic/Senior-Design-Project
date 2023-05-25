export class CarouselItem {

    public title: string;
    public component: string;
    public svg: string;

    constructor(title: string, component: string, svg: string) {
        this.title = title;
        this.component = component;
        this.svg = svg;
    }
}