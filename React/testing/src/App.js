import './App.css';
import Product from "./Product";
import ProductClass from './ProductClass';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1 className="hello">Welcome to our online beauty supply!</h1>
      </header>

      
      <Product 
      name="Mascara" 
      brand="Maybelline"
      price={59.99}/>

  	  <Product 
      name="Blush" 
      brand="Essence"
      price={19.99}/>

     <ProductClass
     name="something!" />

    </div>
  );
}

export default App;


