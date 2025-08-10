import { Stack } from '@mui/material';
import './App.css';
import Header from './components/header';
import { Product } from './domain/product'
import ProductCard from './components/productCard';

const products: Product[] = [];

for (let index = 0; index < 100; index++) {
  products.push({
    id: index.toString(),
    name: `Товар ${index}`,
    photo: "",
    rating: Math.floor(Math.random() * 6)
  })
}

function App() {
  return (
    <div className="App">
      <Header/>
      <Stack direction={"row"} gap={1} mx={1} mt={10} flexWrap={"wrap"}>
        {products.map(p => <ProductCard key={p.id} product={p}/>)}
      </Stack>
    </div>
  );
}

export default App;
