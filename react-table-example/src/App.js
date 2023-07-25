import Form from "./components/Form";
import Table from "./components/Table";
import React, { useState, useEffect } from "react";

const App = () => {
  const [data, setData] = useState(
    localStorage.getItem("data") ? JSON.parse(localStorage.getItem("data")) : []
  );
  const [editData, setEditData] = useState(null);

  useEffect(() => {
    const savedData = localStorage.getItem("data");
    if (savedData) {
      setData(JSON.parse(savedData));
    }
  }, []);

  useEffect(() => {
    localStorage.setItem("data", JSON.stringify(data));
  }, [data]);

  const handleAddRow = (formData) => {
    if (editData !== null) {
      setData((prevData) =>
        prevData.map((item, index) => (index === editData ? formData : item))
      );
      localStorage.setItem("data", JSON.stringify(data));
      setEditData(null);
    } else {
      setData((prevData) => [...prevData, formData]);
    }
  };

  const handleEditRow = (index) => {
    setEditData(index);
  };

  const handleDeleteRow = (index) => {
    setData((prevData) => prevData.filter((_, i) => i !== index));
    setEditData(null);
  };

  return (
    <div>
      <Form
        onSubmit={handleAddRow}
        editData={editData !== null ? data[editData] : null}
      />
      <Table
        data={data}
        onEdit={handleEditRow}
        onDelete={handleDeleteRow}
        setEditData={setEditData}
      />
    </div>
  );
};

export default App;
