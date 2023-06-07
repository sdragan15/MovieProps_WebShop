import styles from "../../styles/myCart.css";
import CartItem from "./cartItem";

function MyCart() {
  let items = [];

  if (localStorage["items"] != "") {
    let temp = localStorage["items"];
    items = JSON.parse(temp);
  }

  return (
    <>
      <div className="cart-wrapper">
        <div>
          <h1>My Cart</h1>
        </div>
        <div className="cart-item-container">
          {items.map((item) => (
            <CartItem
              key={item.id}
              name={item.name}
              description={item.description}
              price={item.price}
              buyNo={item.buyNo}
              image={item.image}
            />
          ))}
        </div>
      </div>
    </>
  );
}

export default MyCart;
