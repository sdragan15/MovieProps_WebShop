import styles from "../styles/mainShop.css";
import Item from "./items-comp/item";

function MainShop() {
  return (
    <>
      <div className="shop-wrapper">
        <div className="shop-search-wrapper">
          <input type="text" />
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
            <Item
              name={"Top gun plane"}
              description={
                "ovo jes aosigdj osaigjdgsdsga gsadg ads gdas glia; j;dg s"
              }
              price={"55"}
              image={
                "https://m.media-amazon.com/images/I/71Cxh1kebjL._AC_UY1000_.jpg"
              }
            />
            <Item />
            <Item />

            <Item />
            <Item />
          </div>
        </div>
      </div>
    </>
  );
}

export default MainShop;
