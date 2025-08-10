export class Product{
    constructor(
        public id: string,
        public name: string,
        public rating: number,
        public photo: string | null
    ){}
}