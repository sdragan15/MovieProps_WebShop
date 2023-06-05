import { ItemModel } from "../../models/item.model";
import styles from "../../styles/modals.css";

function AddItemModal({
  setShow,
  name,
  description,
  price,
  image,
  quantity,
  buyNo,
  setByNo,
  addToCart,
}) {
  const setChanger = (event) => {
    setShow(false);
  };

  const stopPropagation = (event) => {
    event.stopPropagation();
  };

  const Add = () => {
    if (buyNo < quantity) {
      buyNo++;
      setByNo(buyNo);
    }
  };

  const Subtract = () => {
    if (buyNo > 0) {
      buyNo--;
      setByNo(buyNo);
    }
  };

  const AddToCart = () => {
    addToCart(buyNo);
    setChanger();
  };

  return (
    <>
      <div className="modal-wrapper" onClick={setChanger}>
        <div className="modal-container" onClick={stopPropagation}>
          <div
            className="modal-photo"
            style={{ backgroundImage: `url(${image})` }}
          ></div>
          <div className="modal-info-wrapper">
            <div className="modal-info-main">
              <span className="modal-info-header">{name}</span>
              <span className="modal-info-description">{description}</span>
              <span className="modal-info-price">${price}</span>
            </div>
            <div className="modal-info-buttons">
              <div onClick={AddToCart} className="button add-to-cart-btn">
                <span>ADD TO CART</span>
              </div>
              <div className="quantity">
                <span className="quantity-simbol" onClick={Subtract}>
                  -
                </span>
                <span className="quantity-no">{buyNo}</span>
                <span className="quantity-simbol" onClick={Add}>
                  +
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default AddItemModal;
