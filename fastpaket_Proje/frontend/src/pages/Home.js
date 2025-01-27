function App() {
    const [restoranlar, setRestoranlar] = React.useState([]);

    React.useEffect(() => {
        // Örnek veri
        setRestoranlar([
            {
                id: 1,
                ad: "Lezzet Dünyası",
                kategori: "Türk Mutfağı",
                puan: 4.5
            },
            {
                id: 2,
                ad: "Pizza Express",
                kategori: "İtalyan Mutfağı",
                puan: 4.3
            }
        ]);
    }, []);

    return (
        <div className="container mx-auto p-4">
            <header className="text-center mb-8">
                <h1 className="text-3xl font-bold text-blue-600">FastPaket</h1>
                <p className="text-gray-600">En lezzetli yemekler kapınızda!</p>
            </header>

            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                {restoranlar.map(restoran => (
                    <div key={restoran.id} className="border rounded-lg p-4 shadow-md">
                        <h2 className="text-xl font-semibold">{restoran.ad}</h2>
                        <p className="text-gray-600">{restoran.kategori}</p>
                        <div className="flex items-center mt-2">
                            <span className="text-yellow-500">★</span>
                            <span className="ml-1">{restoran.puan}</span>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}