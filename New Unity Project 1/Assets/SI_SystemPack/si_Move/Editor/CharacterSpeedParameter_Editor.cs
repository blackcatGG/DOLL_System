using UnityEngine;
using UnityEditor;
using System.Collections;

public enum CharacterSpeedEditType
{
    State,VolType
}

[CustomEditor (typeof (CharacterSpeedParameter))]
public class CharacterSpeedParameter_Editor : Editor {

    static CharacterSpeedEditType editType;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        CharacterSpeedParameter obj = target as CharacterSpeedParameter;

        InspectorSopprt(obj);

        EditorUtility.SetDirty(target);

    }

    public static void InspectorSopprt(CharacterSpeedParameter obj)
    {
        EditorGUILayout.LabelField("編集タイプ");

        if(GUILayout.Button("状態別", GUILayout.Width(80.0f))){
            editType = CharacterSpeedEditType.State;
        }
        else if(GUILayout.Button("種類別",GUILayout.Width(80.0f)))
        {
            editType = CharacterSpeedEditType.VolType;
        }

        switch (editType)
        {
            case CharacterSpeedEditType.State:

                //通常
                EditorGUILayout.LabelField("通常移動時");
                obj.normal = EditorGUILayout.Slider("　速度",obj.normal,0.0f,60.0f);
                obj.normal_anim = EditorGUILayout.TextField("　再生アニメーション", obj.normal_anim);
                obj.normal_direction_per = EditorGUILayout.Slider("　進行方向の変化率",obj.normal_direction_per,0.0f,120.0f);
                EditorGUILayout.LabelField("　変化率　→　"+(obj.normal_direction_per/60.0f*100.0f)+"%");

                EditorGUILayout.Space();
                //クイック
                EditorGUILayout.LabelField("ラピッドスラスト時");
                obj.quick = EditorGUILayout.Slider("　速度",obj.quick,0.0f,120.0f);
                obj.quicktime = EditorGUILayout.Slider("　時間(F)",obj.quicktime,0.0f,60.0f);
                obj.quick_energy = EditorGUILayout.FloatField("　EN消費",obj.quick_energy);
                obj.quick_anim = EditorGUILayout.TextField("　再生アニメーション",obj.quick_anim);
                obj.quick_direction_per = EditorGUILayout.Slider("　進行方向の変化率",obj.quick_direction_per,0.0f,120.0f);
                EditorGUILayout.LabelField("　変化率　→　"+(obj.quick_direction_per/60.0f*100.0f)+"%");
                EditorGUILayout.LabelField("　EN消費量");
                EditorGUILayout.LabelField("　" + obj.quick_energy + "　＋　" + obj.quick_energy / 60.0f * obj.quicktime + "　＝　" + (obj.quick_energy * (obj.quicktime/60.0f+1.0f)));

                EditorGUILayout.Space();
                //ブースト
                EditorGUILayout.LabelField("ブースト時");
                obj.boost = EditorGUILayout.Slider("　速度", obj.boost, 0.0f, 120.0f);
                obj.second_boost_time = EditorGUILayout.Slider("　時間(F)",obj.second_boost_time,0.0f,60.0f);
                obj.boost_energy = EditorGUILayout.FloatField("　EN消費",obj.boost_energy);
                obj.boost_anim = EditorGUILayout.TextField("　再生アニメーション",obj.boost_anim);
                obj.boost_direction_per = EditorGUILayout.Slider("　進行方向の変化率",obj.boost_direction_per,0.0f,120.0f);
                EditorGUILayout.LabelField("　変化率　→　"+(obj.boost_direction_per/60.0f*100.0f)+"%");
                EditorGUILayout.LabelField("　EN消費量");
                EditorGUILayout.LabelField("　" + obj.boost_energy / 60.0f * obj.second_boost_time);

                EditorGUILayout.Space();
                //セカンド
                EditorGUILayout.LabelField("セカンド時");
                obj.second_boost = EditorGUILayout.Slider("　速度", obj.second_boost, 0.0f, 120.0f);
                obj.second_boost_energy = EditorGUILayout.FloatField("　EN消費", obj.second_boost_energy);
                obj.second_anim = EditorGUILayout.TextField("　再生アニメーション", obj.second_anim);
                obj.second_direction_per = EditorGUILayout.Slider("　進行方向の変化率", obj.second_direction_per, 0.0f, 120.0f);
                EditorGUILayout.LabelField("　変化率　→　" + (obj.second_direction_per / 60.0f * 100.0f) + "%");
                EditorGUILayout.LabelField("　EN消費量");
                EditorGUILayout.LabelField("　" + (obj.second_boost_energy/60.0f) );

                break;
            case CharacterSpeedEditType.VolType:
                
                //速度
                EditorGUILayout.LabelField("速度");
                obj.normal = EditorGUILayout.Slider("　通常", obj.normal, 0.0f, 60.0f);
                obj.quick = EditorGUILayout.Slider("　RT", obj.quick, 0.0f, 120.0f);
                obj.boost = EditorGUILayout.Slider("　ブースト", obj.boost, 0.0f, 120.0f);
                obj.second_boost = EditorGUILayout.Slider("　セカンド", obj.second_boost, 0.0f, 120.0f);

                EditorGUILayout.Space();
                //時間
                EditorGUILayout.LabelField("時間(F)");
                obj.quicktime = EditorGUILayout.Slider("　RT", obj.quicktime, 0.0f, 60.0f);
                obj.second_boost_time = EditorGUILayout.Slider("　ブースト", obj.second_boost_time, 0.0f, 60.0f);

                EditorGUILayout.Space();
                //アニメーション
                EditorGUILayout.LabelField("アニメーション");
                obj.normal_anim = EditorGUILayout.TextField("　通常", obj.normal_anim);
                obj.quick_anim = EditorGUILayout.TextField("　RT", obj.quick_anim);
                obj.boost_anim = EditorGUILayout.TextField("　ブースト", obj.boost_anim);
                obj.second_anim = EditorGUILayout.TextField("　セカンド", obj.second_anim);

                EditorGUILayout.Space();
                //EN
                EditorGUILayout.LabelField("消費EN");
                obj.quick_energy = EditorGUILayout.FloatField("　RT", obj.quick_energy);
                obj.boost_energy = EditorGUILayout.FloatField("　ブースト", obj.boost_energy);
                obj.second_boost_energy = EditorGUILayout.FloatField("　セカンド", obj.second_boost_energy);

                EditorGUILayout.Space();
                //変化率
                EditorGUILayout.LabelField("進行方向変化率");
                obj.normal_direction_per = EditorGUILayout.Slider("　通常", obj.normal_direction_per, 0.0f, 120.0f);
                obj.quick_direction_per = EditorGUILayout.Slider("　RT", obj.quick_direction_per, 0.0f, 120.0f);
                obj.boost_direction_per = EditorGUILayout.Slider("　ブースト", obj.boost_direction_per, 0.0f, 120.0f);
                obj.second_direction_per = EditorGUILayout.Slider("　セカンド", obj.second_direction_per, 0.0f, 120.0f);
                break;
        }

    }

}
