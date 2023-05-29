import { useState } from "react";
import styles from "../styles/mainShop.css";
import Item from "./items-comp/item";
import AddItemModal from "./modals-comp/addItemModal";
import { ItemModel } from "../models/item.model";

function AddItems(items) {
  for (let i = 1; i <= 10; i++) {
    let temp = new ItemModel();
    temp.name = "Name_" + i;
    temp.description = "Ovo je nekakav opis " + i + ".";
    temp.price = 100 * i + 8 * i;
    temp.quantity = i;
    items.push(temp);
  }
}

function MainShop() {
  let items = [];

  const [clickedItem, setClickedItem] = useState(null);
  const [show, setShow] = useState(false);

  AddItems(items);

  const openAddItemModal = (event, item) => {
    setClickedItem(item);
    setShow(true);
  };

  return (
    <>
      <div className="shop-wrapper">
        <div className="shop-search-wrapper">
          <input type="text" placeholder="Search" />
        </div>
        <div className="shop-main-wrapper">
          <div className="shop-sidebar">
            <div className="shop-sidebar-item">
              <span>Sort by</span>
              <span>^</span>
            </div>
            <div className="shop-sidebar-item">
              <span>Sort by</span>
              <span>^</span>
            </div>
          </div>
          <div className="shop-items-wrapper">
            {items.map((item) => (
              <Item
                key={item.name}
                name={item.name}
                description={item.description}
                price={item.price}
                image={
                  "https://m.media-amazon.com/images/I/71Cxh1kebjL._AC_UY1000_.jpg"
                }
                onClick={(event) => openAddItemModal(event, item)}
              />
            ))}
          </div>
        </div>
      </div>
      {show && (
        <AddItemModal
          setShow={setShow}
          name={clickedItem.name}
          description={clickedItem.description}
          image={
            "https://m.media-amazon.com/images/I/71Cxh1kebjL._AC_UY1000_.jpg"
          }
          price={clickedItem.price}
        />
      )}
    </>
  );
}

export default MainShop;
