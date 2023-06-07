function MyInput({ text, type, name, value, onChange, maxWidth, maxHeight }) {
  let input = (
    <input
      className="input-my"
      type={type}
      name={name}
      value={value}
      onChange={onChange}
    ></input>
  );

  if (type == "textarea") {
    input = (
      <textarea
        style={{ maxWidth: maxWidth + "rem", maxHeight: maxHeight + "rem" }}
        className="input-my"
        value={value}
        onChange={onChange}
        name={name}
      ></textarea>
    );
  }

  return (
    <>
      <div className="input-form">
        <span className="input-text">{text}</span>
        {input}
      </div>
    </>
  );
}

export default MyInput;
