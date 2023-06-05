function MyInput({ text, type, name, value, onChange }) {
  return (
    <>
      <div className="input-form">
        <span className="input-text">{text}</span>
        <input
          className="input-my"
          type={type}
          name={name}
          value={value}
          onChange={onChange}
        ></input>
      </div>
    </>
  );
}

export default MyInput;
