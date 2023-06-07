import styles from "../../styles/myCart.css";

function CartItem({ name, description, price, buyNo, image }) {
  return (
    <>
      <div className="cart-item">
        <img className="cart-image" src={image}></img>
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
