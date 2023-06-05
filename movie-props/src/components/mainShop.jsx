import { useEffect, useState } from "react";
import styles from "../styles/mainShop.css";
import Item from "./items-comp/item";
import AddItemModal from "./modals-comp/addItemModal";
import { ItemModel } from "../models/item.model";
import ItemService from "../services/item.service";

let itemService = ItemService;

function MainShop() {
  itemService = new ItemService();

  const [clickedItem, setClickedItem] = useState(null);
  const [show, setShow] = useState(false);
  const [items, setItems] = useState([]);
  const [buyNo, setBuyNo] = useState(0);

  useEffect(() => {
    itemService
      .getAll()
      .then((res) => {
        if (res.status == 200) {
          console.log(res.data);
          setItems(res.data);
        } else {
          console.log(res.message);
        }
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const openAddItemModal = (event, item) => {
    setBuyNo(0);
    setClickedItem(item);
    setShow(true);
  };

  const addToCart = (no) => {
    if (no <= 0) {
      return;
    }
    clickedItem.buyNo = no;
    if (localStorage["items"] == "") {
      let myItems = [];
      myItems.push(clickedItem);
      localStorage["items"] = JSON.stringify(myItems);
    } else {
      let myItems = JSON.parse(localStorage["items"]);
      myItems.push(clickedItem);
      localStorage["items"] = JSON.stringify(myItems);
    }
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
          quantity={clickedItem.quantity}
          buyNo={buyNo}
          setByNo={setBuyNo}
          addToCart={addToCart}
        />
      )}
    </>
  );
}

export default MainShop;
