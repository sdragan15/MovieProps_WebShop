import styles from "../../styles/myCart.css";

function CartItem({ item, isBuyNo, isDelete, isEdit, onEdit, onDelete }) {
  const handleEdit = () => {
    onEdit(item);
  };

  const handleDelete = () => {
    onDelete(item);
  };

  let buyNoComp = (
    <>
      <div className="quantity item">
        <span className="quantity-simbol">-</span>
        <span className="quantity-no">{item.buyNo}</span>
        <span className="quantity-simbol">+</span>
      </div>
    </>
  );

  let editComp = (
    <>
      <span onClick={handleEdit} className="cart-edit">
        Edit
      </span>
    </>
  );

  let deleteComp = (
    <>
      <span onClick={handleDelete} className="cart-edit">
        Delete
      </span>
    </>
  );

  return (
    <>
      <div className="cart-item">
        <img className="cart-image" src={item.image}></img>
        <span className="cart-name item">{item.name}</span>
        <span className="cart-description">{item.description}</span>
        <span className="cart-price">${item.price}</span>
        <div className="cart-end">
          {isBuyNo && buyNoComp}
          {isEdit && editComp}
          {isDelete && deleteComp}
        </div>
      </div>
    </>
  );
}

export default CartItem;
