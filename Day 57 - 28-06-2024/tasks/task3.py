def top_10_players(players):
    sorted_players = sorted(players, key=lambda x: (-x['score'], x['name']))
    return sorted_players[:10]

players = [
    {'name': 'Ram', 'score': 50},
    {'name': 'Raj', 'score': 40},
    {'name': 'Alex', 'score': 60},
    {'name': 'Rahul', 'score': 60},
]

top_players = top_10_players(players)
for player in top_players:
    print(player)
