import { useState } from "react";
import 'bootstrap/dist/css/bootstrap.css';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

export default function CalendarForm({ submitForm }) {
  const [formData, setFormData] = useState({ title: "", description: "", start: "", end: "" });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevFormData) => ({ ...prevFormData, [name]: value }));
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    submitForm(formData.title, formData.description, formData.start, formData.end);
  };

  return (
    <>
      <h4>Add Event</h4>
      <Form onSubmit={handleSubmit}>
        <Form.Group>
          <Form.Label>Title:</Form.Label>
          <Form.Control required type="text" id="title" name="title" value={formData.title} onChange={handleChange} />
        </Form.Group>
        <Form.Group>
          <Form.Label>Description:</Form.Label>
          <Form.Control required type="text" id="description" name="description" value={formData.description} onChange={handleChange} />
        </Form.Group>
        <Form.Group>
          <Form.Label>Start:</Form.Label>
          <Form.Control required type="date" id="start" name="start" value={formData.start} onChange={handleChange} />
        </Form.Group>
        <Form.Group>
          <Form.Label>End:</Form.Label>
          <Form.Control required type="date" id="end" name="end" value={formData.end} onChange={handleChange} />
        </Form.Group>
        <br/>
        <Button variant="primary" type="submit">
          Add
        </Button>
      </Form>
    </>
  );
}