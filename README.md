# 🛍️ E-Commerce Product Listing App

This is a simple and functional **e-commerce product listing website** built using:

- 💻 **ASP.NET Core Web API** (Backend)
- 🌐 **Vue.js** (Frontend)

It demonstrates core features like:
- Product display with images
- Category and price filtering
- Pagination
- API-driven UI

---

## ✨ Features

✅ Displays 12 products  
✅ 6 products per page (3 in each row)  
✅ Filter by:
- 🔍 Product name (search)
- 🏷️ Category
- 💰 Price range (min-max)

✅ Includes:
- 📸 Product images (served from ASP.NET backend)
- 📄 Pagination (Next/Prev)
- 💚 Styled prices in green
- 🎨 Clean responsive UI

---

## 🛠️ Technologies Used

| Layer      | Tech                       |
|------------|----------------------------|
| Frontend   | Vue.js, Axios, CSS         |
| Backend    | ASP.NET Core Web API       |
| Image Host | wwwroot/images (static files) |

---

## 🚀 How to Run

### 🖥 Backend (ASP.NET Core)

```bash
cd backend
dotnet run

-- Frontend Structure (Vue.js)
frontend/
├── public/
│   └── index.html             # Main HTML file
├── src/
│   ├── assets/                # Static images or styles (optional)
│   ├── components/
│   │   └── ProductList.vue    # Main component for listing products
│   ├── App.vue                # Root Vue component
│   ├── main.js                # Entry point for Vue app
├── vue.config.js              # Proxy config to connect frontend with backend
├── package.json               # Project dependencies

📁 Overall Project Structure
ecom-website/
├── backend/         → ASP.NET Core Web API
│   ├── Controllers/
│   ├── Models/
│   └── wwwroot/images/
├── frontend/        → Vue.js application
│   ├── src/components/ProductList.vue
│   └── vue.config.js
├── README.md



👤 Author

 Ajay Jayz

🌐 GitHub: @Ajayjayz

🧠 Aspiring Full-Stack Developer

📄 License
This project is open-source and built for educational/demo purposes.
Feel free to explore, learn, and build upon it.
