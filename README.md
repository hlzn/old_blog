OldBlog
A modern full-stack blog application built with ASP.NET Core and Vue 3.

Tech Stack
Backend
.NET 9.0 / ASP.NET Core 9.0
FastEndpoints 6.0.0 — lightweight endpoint-based API architecture
Entity Framework Core 9.0.4 — ORM with code-first migrations
PostgreSQL — primary database (via Npgsql 9.0.4)
Sqids 3.1.0 — URL-friendly opaque ID encoding
Frontend
Vue 3.5.13 — Composition API with <script setup>
TypeScript 5.6.2
Vite 6.0.5 — build tool with HMR
Pinia 2.3.0 — state management
Vue Router 4.5.1 — client-side routing
Project Structure

oldblog/
├── hlzn1/
│   ├── Endpoints/        # FastEndpoints API handlers
│   ├── Services/         # Business logic (read/write separation)
│   ├── Models/           # Domain models and DTOs
│   ├── Data/             # EF Core DbContext
│   ├── Migrations/       # Database schema migrations
│   ├── Client/           # Vue frontend
│   │   └── src/
│   │       ├── components/   # Vue components (feature-based)
│   │       ├── stores/       # Pinia stores
│   │       ├── models/       # TypeScript interfaces
│   │       └── router.ts     # Route definitions
│   ├── appsettings.json
│   └── Dockerfile
└── oldblog.sln
API Endpoints
Method	Route	Description
GET	/api/blog/posts/{page}	Paginated blog posts
GET	/api/blog/post/{id}	Single post by encoded ID
GET	/api/blog/post/about/{id}	About Me post
GET	/health	Health check
Routes
Path	Component	Description
/	FrontDoor	Home / post listing
/story/:storyid	FrontDoorStory	Individual blog post
/about	About	About page
Getting Started
Prerequisites
.NET 9 SDK
Node.js / npm
PostgreSQL
Backend

# Set your connection string
export ConnectionStrings__DefaultConnection="Host=...;Database=...;Username=...;Password=..."

# Run (migrations apply automatically on startup)
dotnet run --project hlzn1
Frontend

cd hlzn1/Client
npm install
npm run dev       # development
npm run build     # production build
Docker

docker build -t oldblog ./hlzn1
docker run -p 8080:8080 -e ConnectionStrings__DefaultConnection="..." oldblog
