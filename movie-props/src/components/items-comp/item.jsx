function Item({ name, description, price, image, onClick }) {
  return (
    <>
      <div className="shop-item" onClick={onClick}>
        <div className="item-photo-wrapper">
          <div>
            <img className="item-photo" src={image}></img>
          </div>
        </div>
        <span className="item-name">{name}</span>
        <span className="item-description">{description}</span>
        <span className="item-price">${price}</span>
      </div>
    </>
  );
}

export default Item;
