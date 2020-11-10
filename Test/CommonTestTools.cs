namespace TestCore {
	class CommonTestTools {
		public class SerializableClass {
			public int Number { get; set; }
			public string Text { get; set; }
			public SerializableSubClass SubClass { get; set; }
			public bool Bool { get; set; }

			public override bool Equals(object obj) {
				if (obj is SerializableClass) {
					var other = obj as SerializableClass;
					return Number == other.Number
						&& Text == other.Text
						&& Bool == other.Bool
						&& SubClass.Equals(other.SubClass);
				}
				return false;
			}

			public override int GetHashCode() {
				return base.GetHashCode();
			}

			public class SerializableSubClass {
				public float DecimalNumber { get; set; }
				public long LongNumber { get; set; }
				public char Letter { get; set; }

				public override bool Equals(object obj) {
					if (obj is SerializableSubClass) {
						var other = obj as SerializableSubClass;
						return DecimalNumber == other.DecimalNumber
							&& LongNumber == other.LongNumber
							&& Letter == other.Letter;
					}
					return false;
				}

				public override int GetHashCode() {
					return base.GetHashCode();
				}
			}
		}
	}
}
