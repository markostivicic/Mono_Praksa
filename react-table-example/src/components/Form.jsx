import React, { useState, useEffect } from 'react';

const Form = ({ onSubmit, editData }) => {
  const [formData, setFormData] = useState({ name: '', job: '' });

  useEffect(() => {
    if (editData) {
      setFormData(editData);
    }
  }, [editData]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevFormData) => ({
      ...prevFormData,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
    setFormData({ name: '', job: '' });
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        name="name"
        placeholder="Name"
        value={formData.name || ''}
        onChange={handleChange}
        required
      />
      <input
        type="text"
        name="job"
        placeholder="Job"
        value={formData.job || ''}
        onChange={handleChange}
        required
      />
      <button type="submit">{editData ? 'Save' : 'Add'}</button>
    </form>
  );
};

export default Form;
