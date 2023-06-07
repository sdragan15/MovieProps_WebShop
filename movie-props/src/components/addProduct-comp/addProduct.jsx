import { useEffect, useState } from "react";
import styles from "../../styles/addProduct.module.css";
import MyInput from "../input-comp/myInput";
import ItemService from "../../services/item.service";
import { ItemModel } from "../../models/item.model";
import { resolvePath } from "react-router-dom";

function AddProduct() {
  const itemService = new ItemService();

  const [item, setItem] = useState(new ItemModel());
  const [image, setImage] = useState(null);
  const [imageUrl, setImageUrl] = useState();

  useEffect(() => {
    if (image != null) {
      const temp = URL.createObjectURL(image);
      setImageUrl(temp);
      setItem((prevState) => ({
        ...prevState,
        image: temp,
      }));
    }
  }, [image]);

  const onImageChange = (e) => {
    setImage(e.target.files[0]);
  };

  const uploadData = (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("image", image);
    formData.append("name", item.name);
    formData.append("description", item.description);
    formData.append("price", item.price);
    formData.append("quantity", item.quantity);

    itemService
      .addItem(formData)
      .then((response) => {
        if (response.status == 200) {
          alert("Success");
        } else {
          console.log(response.message);
        }
      })
      .catch((error) => {
        console.log(error.message);
      });
  };

  return (
    <>
      <div className={styles.addProductWrapper}>
        <form method="post" onSubmit={uploadData}>
          <div className={styles.productFormContainer}>
            <div className={styles.productInputs}>
              <span>Product name:</span>
              <MyInput
                name={"name"}
                type={"text"}
                value={item.name}
                onChange={(e) =>
                  setItem((prevState) => ({
                    ...prevState,
                    name: e.target.value,
                  }))
                }
              />
              <span>Description:</span>
              <MyInput
                name={"description"}
                type={"textarea"}
                value={item.description}
                maxWidth={"25"}
                maxHeight={"20"}
                onChange={(e) =>
                  setItem((prevState) => ({
                    ...prevState,
                    description: e.target.value,
                  }))
                }
              />
              <span>Price (rsd):</span>
              <MyInput
                value={item.price}
                name={"price"}
                type={"number"}
                onChange={(e) =>
                  setItem((prevState) => ({
                    ...prevState,
                    price: e.target.value,
                  }))
                }
              />
              <span>Quantity:</span>
              <MyInput
                value={item.quantity}
                name={"quantity"}
                type={"number"}
                onChange={(e) =>
                  setItem((prevState) => ({
                    ...prevState,
                    quantity: e.target.value,
                  }))
                }
              />
            </div>
            <div className={styles.productImage}>
              <img className={styles.img} src={imageUrl}></img>
              <input
                className={styles.imageInput}
                type="file"
                accept="image/*"
                onChange={onImageChange}
              ></input>
            </div>
          </div>
          <div className={styles.submit}>
            <button className="submit-btn">Add</button>
          </div>
        </form>
      </div>
    </>
  );
}

export default AddProduct;
