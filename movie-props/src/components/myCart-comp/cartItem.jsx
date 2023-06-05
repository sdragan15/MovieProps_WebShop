import styles from "../../styles/myCart.css";

function CartItem({ name, description, price, buyNo }) {
  return (
    <>
      <div className="cart-item">
        <img
          className="cart-image"
          src="https://m.media-amazon.com/images/I/71Cxh1kebjL._AC_UY1000_.jpg"
        ></img>
        <span className="cart-name item">{name}</span>
        <span className="cart-description">{description}</span>
        <span className="cart-price">${price}</span>
        <div className="quantity item">
          <span className="quantity-simbol">-</span>
          <span className="quantity-no">{buyNo}</span>
          <span className="quantity-simbol">+</span>
        </div>
      </div>
    </>
  );
}

export default CartItem;
